// Toggle the sidebar's collapsed state
const sidebar = document.querySelector('.sidebar');
const toggleButton = document.querySelector('.toggle');
toggleButton.addEventListener('click', () => {

    sidebar.classList.toggle('collapsed');

    document.querySelector(".navbar").classList.toggle('collapsed')
    document.querySelector("#main-content").classList.toggle('collapsed')
    document.querySelector(".sidebar_parent").classList.toggle('collapsed')
    document.querySelector(".sider_main_head").classList.toggle('collapsed')
    const img = document.querySelector(".sidebar_heade")
    const logo = document.querySelector(".logo .img_mainlogo")
    console.log(logo)
    img.classList.contains("collapsed")
        ? (logo.src = "/images/Logo.svg")
        : (logo.src = "/images/logo1.svg");



    img.classList.toggle('collapsed')


});
