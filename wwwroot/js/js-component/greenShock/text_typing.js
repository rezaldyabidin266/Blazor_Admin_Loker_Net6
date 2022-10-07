function typingJudul() {
    gsap.registerPlugin(TextPlugin);

    const judul = document.querySelector('.judul h1 span');
    gsap.to(judul, {
        duration: 3,
        text: {
            value: " mulai dari video tutorial sampai potongan code.",
        },
        ease:"none"
    });

}