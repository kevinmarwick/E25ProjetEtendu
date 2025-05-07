console.log("site.js loaded");

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

// Input filtering still fine outside
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
