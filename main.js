function getChildren(n, skipMe){
    var r = [];
    for ( ; n; n = n.nextSibling ) 
       if ( n.nodeType == 1 && n != skipMe)
          r.push( n );        
    return r;
};

function getSiblings(n) {
    return getChildren(n.parentNode.firstChild, n);
}

function navigate(id) {
    var el = document.getElementById(id);
    for (var ei of getSiblings(el.parentNode.firstChild)) {
        ei.style.display = 'none';
    }
    el.style.display = 'block';
}

window.onload = function() {
    var content = document.getElementById('content');
    for (var ei of content.children) {
        ei.style.display = 'none';
    }
    //alert(content.firstElementChild.style);
    content.firstElementChild.style.display = 'block';
}
