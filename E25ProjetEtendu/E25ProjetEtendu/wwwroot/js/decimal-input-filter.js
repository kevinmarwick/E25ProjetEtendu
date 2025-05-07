document.addEventListener('input', function (e) {
    if (e.target.matches('.decimal-only')) {
        let val = e.target.value;

        // Allow only digits, comma, and period
        val = val.replace(/[^0-9.,]/g, '');
        val = val.replace(/[eE]/g, ''); // block scientific notation

        // Allow only one decimal separator
        const parts = val.split(/[,\.]/);
        if (parts.length > 2) {
            val = parts[0] + '.' + parts.slice(1).join('');
        }

        e.target.value = val;
    }  

});
document.addEventListener('input', function (e) {
    if (e.target.matches('.int-only')) {
        e.target.value = e.target.value.replace(/\D/g, ''); // digits only
    }
});
