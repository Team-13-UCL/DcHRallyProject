// Handle accordion collapse behavior
document.querySelectorAll('.accordion-button').forEach(function (button) {
    button.addEventListener('click', function () {
        const target = this.getAttribute('data-bs-target');
        const allCollapses = document.querySelectorAll('.accordion-collapse');
        allCollapses.forEach(function (collapse) {
            if (collapse.getAttribute('id') !== target) {
                collapse.classList.remove('show');
            }
        });
    });
});

// Handle obstacle information on hover 
document.querySelectorAll('.obstacle-image').forEach(function(image) {
    let timeout;
    
    image.addEventListener('mouseenter', function(e) {
        const obstacleName = image.getAttribute('alt');
        /*console.log('Obstacle Name:', obstacleName);*/
        timeout = setTimeout(function() {
            showTooltip(e.clientX, e.clientY, obstacleName);
        }, 1000); // Adjust the delay as needed
    });
    
    image.addEventListener('mouseleave', function() {
        clearTimeout(timeout);
        hideTooltip();
    });
});

function showTooltip(x, y, text) {
    const tooltip = document.createElement('div');
    tooltip.className = 'obstacle-tooltip';
    tooltip.textContent = text;
    tooltip.style.left = x + 'px';
    tooltip.style.top = y + 'px';
    document.body.appendChild(tooltip);
}

function hideTooltip() {
    const tooltip = document.querySelector('.obstacle-tooltip');
    if (tooltip) {
        tooltip.remove();
    }
}

