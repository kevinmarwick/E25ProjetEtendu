// Patch jQuery validation to support French decimal commas

$(function () {
    // Make sure jQuery + validation plugins are ready
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


//    Enforce input format:
// - .decimal-only → max 2 decimals, support comma input
// - .int-only → digits only
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
    if (!input) return; // not all pages have it

    // Load saved location from localStorage
    const saved = localStorage.getItem("deliveryLocation");
    if (saved) {
        input.value = saved;
    }

    // Save on input
    input.addEventListener("input", function () {
        localStorage.setItem("deliveryLocation", String(this.value));

    });
});

//Send Order
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

