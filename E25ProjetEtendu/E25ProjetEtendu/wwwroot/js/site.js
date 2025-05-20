// Patch jQuery validation to support French decimal commas
function showToast(message, type = "success") {
    const toastEl = document.getElementById("toastMessage");
    if (!toastEl) return;

    toastEl.className = `toast align-items-center text-white bg-${type} border-0`;
    const toastBody = toastEl.querySelector(".toast-body");
    if (toastBody) toastBody.textContent = message;

    const bsToast = new bootstrap.Toast(toastEl);
    bsToast.show();
}

// Ajout au panier
$(document).on('click', '.add-to-cart', function () {
    if (typeof isAuthenticated !== "undefined" && !isAuthenticated) {
        window.location.href = '/Identity/Account/Login';
        return;
    }

    const productId = parseInt($(this).data('productid'));
    const productName = $(this).data('productname');
    const price = parseFloat($(this).data('price'));
    const image = $(this).data('image');
    const maxStock = parseInt($(this).data('stock'));

    const storageKey = currentUserId ? 'panier_' + currentUserId : 'panier_guest';
    let cart = JSON.parse(localStorage.getItem(storageKey)) || [];

    let item = cart.find(p => p.ProduitId === productId);

    if (item) {
        if (item.Quantite >= maxStock) {
            showToast("Stock maximum atteint pour ce produit", "warning");
            return;
        }
        item.Quantite += 1;
    } else {
        cart.push({
            ProduitId: productId,
            Nom: productName,
            Prix: price,
            Quantite: 1,
            Image: image,
            Stock: maxStock
        });
    }

    localStorage.setItem(storageKey, JSON.stringify(cart));
    showToast("Produit ajouté au panier");
    updateCartBadge();
    afficherMiniPanier();
    desactiverBoutonsSiStockAtteint();
});

// Désactiver le bouton "Détail" si le stock est atteint
document.addEventListener("DOMContentLoaded", () => {
    const btn = document.getElementById("btn-add-details");
    if (!btn) return;

    const productId = parseInt(btn.dataset.productid);
    const maxStock = parseInt(btn.dataset.stock);
    const userId = document.body.dataset.userid;
    const storageKey = userId ? 'panier_' + userId : 'panier_guest';
    const cart = JSON.parse(localStorage.getItem(storageKey)) || [];

    const item = cart.find(p => p.ProduitId === productId);
    if (item && item.Quantite >= maxStock) {
        btn.disabled = true;
        btn.classList.add("disabled");
        btn.innerText = "Stock maximum atteint";
    }
});

// Désactiver boutons si le stock est atteint
function desactiverBoutonsSiStockAtteint() {
    const userId = document.body.dataset.userid;
    const storageKey = userId ? 'panier_' + userId : 'panier_guest';
    const cart = JSON.parse(localStorage.getItem(storageKey)) || [];

    document.querySelectorAll('.add-to-cart').forEach(btn => {
        const productId = parseInt(btn.dataset.productid);
        const stock = parseInt(btn.dataset.stock);
        const item = cart.find(p => p.ProduitId === productId);

        if (stock === 0 || (item && item.Quantite >= stock)) {
            btn.disabled = true;
            btn.classList.add("disabled");
            btn.innerText = "Stock max atteint";
        }
    });
}

// Met à jour le badge dans l'icône panier
function updateCartBadge() {
    if (!currentUserId) return;

    const storageKey = 'panier_' + currentUserId;
    const cart = JSON.parse(localStorage.getItem(storageKey)) || [];
    const totalQuantity = cart.reduce((acc, item) => acc + item.Quantite, 0);

    const badge = document.getElementById("cart-badge");
    if (!badge) return;

    badge.textContent = totalQuantity;
    badge.style.display = totalQuantity === 0 ? 'none' : 'inline-block';
}

// Affiche les items dans le mini-panier
function afficherMiniPanier() {
    if (!currentUserId) return;

    const storageKey = 'panier_' + currentUserId;
    const cart = JSON.parse(localStorage.getItem(storageKey)) || [];

    const container = $('#cart-summary-content');
    let html = '';

    if (cart.length === 0) {
        html = '<p>Le panier est vide</p>';
    } else {
        html = '<ul class="list-unstyled">';
        cart.forEach(item => {
            html += `<li class="d-flex align-items-center mb-2">
                <img src="/images/${item.Image}" alt="${item.Nom}" style="width:40px; height:40px; object-fit:cover; margin-right:10px;">
                <div><strong>${item.Nom}</strong><br>Qté: ${item.Quantite}</div>
            </li>`;
        });

        const total = cart.reduce((acc, item) => acc + item.Prix * item.Quantite, 0);
        html += `</ul><p class="mt-2"><strong>Total: ${total.toFixed(2)} $</strong></p>`;
    }

    container.html(html);
}

// Initialisation
$(document).ready(function () {
    updateCartBadge();
    afficherMiniPanier();
    desactiverBoutonsSiStockAtteint();

    $(document).on('click', '.add-to-cart', () => {
        setTimeout(() => {
            updateCartBadge();
            afficherMiniPanier();
            desactiverBoutonsSiStockAtteint();
        }, 100);
    });

    $(document).on('click', '.increase-btn, .decrease-btn, #clear-cart-btn', () => {
        setTimeout(() => {
            updateCartBadge();
            afficherMiniPanier();
            desactiverBoutonsSiStockAtteint();
        }, 100);
    });
});

// Patch validation francophone
$(function () {
    if ($.validator && $.validator.methods) {
        $.validator.methods.number = function (value, element) {
            value = value.replace(',', '.');
            return this.optional(element) || !isNaN(parseFloat(value));
        };

        $.validator.methods.range = function (value, element, param) {
            value = value.replace(',', '.');
            return this.optional(element) || (parseFloat(value) >= param[0] && parseFloat(value) <= param[1]);
        };

        console.log("Validation methods patched");
    } else {
        console.warn("jQuery validation not ready when site.js ran");
    }
});

// Enforce input format
document.addEventListener('input', function (e) {
    if (e.target.matches('.decimal-only')) {
        let val = e.target.value;
        const originalComma = val.includes(',');
        val = val.replace(',', '.').replace(/[^0-9.]/g, '');

        const parts = val.split('.');
        if (parts.length > 2) {
            val = parts[0] + '.' + parts.slice(1).join('');
        }
        if (parts[1]?.length > 2) {
            parts[1] = parts[1].substring(0, 2);
            val = parts[0] + '.' + parts[1];
        }

        if (originalComma) {
            val = val.replace('.', ',');
        }

        e.target.value = val;
    }

    if (e.target.matches('.int-only')) {
        e.target.value = e.target.value.replace(/\D/g, '');
    }
});

// Store and restore delivery location input
document.addEventListener("DOMContentLoaded", () => {
    const input = document.getElementById("delivery-location");
    if (!input) return;

    const saved = localStorage.getItem("deliveryLocation");
    if (saved) {
        input.value = saved;
    }

    input.addEventListener("input", function () {
        localStorage.setItem("deliveryLocation", String(this.value));
    });
});

// Envoyer commande
function envoyerCommande() {
    const userId = document.body.dataset.userid;
    const storageKey = 'panier_' + userId;
    const cart = JSON.parse(localStorage.getItem(storageKey)) || [];
    const location = localStorage.getItem("deliveryLocation") || "";

    console.log("storageKey:", storageKey);
    console.log("raw cart:", localStorage.getItem(storageKey));
    console.log("deliveryLocation:", location);

    if (!location.trim()) {
        alert("Veuillez entrer un lieu de livraison.");
        return Promise.reject("Lieu de livraison manquant");
    }

    if (cart.length === 0) {
        alert("Votre panier est vide.");
        return Promise.reject("Panier vide");
    }

    const dto = {
        items: cart.map(item => ({
            productId: item.ProduitId,
            quantity: item.Quantite
        })),
        location: location
    };

    return fetch('/order/create', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dto)
    }).then(res => {
        if (!res.ok) throw new Error("Erreur serveur.");
        return res.json();
    });
}

// Toggle mini-panier
$(document).on('click', '#toggle-cart-btn', function () {
    $('#cart-summary').toggleClass('show');
});


//Send Order

function envoyerCommande(location) {

  

    const userId = document.body.dataset.userid;
    const storageKey = 'panier_' + userId;
    const cart = JSON.parse(localStorage.getItem(storageKey)) || [];

    console.log("storageKey:", storageKey);
    console.log("raw cart:", localStorage.getItem(storageKey));

    if (cart.length === 0) {
        alert("Votre panier est vide.");
        return Promise.reject("Panier vide");
    }

    const dto = {
        items: cart.map(item => ({
            productId: item.ProduitId,
            quantity: item.Quantite
        })),
        location: location
    };

    return fetch('/api/order/create', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dto)
    }).then(res => {
        if (!res.ok) throw new Error("Erreur serveur.");
        return res.json();
    });
}

