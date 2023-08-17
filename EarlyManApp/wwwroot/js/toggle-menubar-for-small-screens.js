/* This script toggles the menu bar for small screens */
document.addEventListener('DOMContentLoaded', () => {
    let hamburger = document.getElementById("hamburgerBtn");
    function toggleMenu() {
        document.getElementsByClassName("authbar")[0].classList.toggle("open");
        /*hamburger.classList.toggle("orange_for_toggler");*/
    }
    hamburger.onclick = toggleMenu;
});