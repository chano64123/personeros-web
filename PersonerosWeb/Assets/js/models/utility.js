function valideKeyNumber(evt) {
    var code = (evt.which) ? evt.which : evt.keyCode;
    if (code >= 48 && code <= 57 || code == 13) {
        return true;
    }
    return false;
}

function capitalizeWords(val) {
        return val.toLowerCase()
        .trim()
        .split(' ')
        .map(v => v[0].toUpperCase() + v.substr(1))
        .join(' ');
}

function count(maxValue, idElement) {
    var counter = { var: 0 };
    var anim = TweenMax.to(counter, 5, {
        var: maxValue,
        onUpdate: function () {
            var number = Math.ceil(counter.var);
            $(idElement).html(number);
            if (number === counter.var) { anim.kill(); }
        },
        onComplete: function () {
            count();
        },
        ease: Circ.easeOut
    });
}