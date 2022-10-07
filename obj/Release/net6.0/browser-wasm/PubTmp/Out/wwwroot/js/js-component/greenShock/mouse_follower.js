function mouse_follow() {

    var mouse_follow = document.querySelector('.mouse-follow');
    var navbar_brand = document.querySelector('.navbar-brand');
    var nav_item = gsap.utils.toArray(".nav-item");
    var nav_sosmed = gsap.utils.toArray(".sosmed");
    gsap.set(mouse_follow, { xPercent: -50, yPercent: -50 });

    let xTo = gsap.quickTo(mouse_follow, "x", { duration: 0.4, ease: "power3" }),
        yTo = gsap.quickTo(mouse_follow, "y", { duration: 0.4, ease: "power3" });

    const maxRot = 25;
    const brandRotY = gsap.quickSetter(navbar_brand, "rotationY", "deg");
    gsap.set(brandRotY, { transformOrigin: "center center" });
    let getPercentY;

    //TimeLine
    let timeLine = gsap.timeline();

    function hover_navbar_brand(e) {
        timeLine.to(mouse_follow, 0.3, {
            scale: 5,
            opacity: 0.7,
            ease: "power3.in",
            background: "#F4B672"
        });
    }

    function unhover_navbar_brand(e) {
        timeLine.to(mouse_follow, 0.3, {
            scale: 1,
            opacity: 1,
            ease: "bounce.out",
            background: "#ED454A"

        });
    }

    function resize() {
        getPercentY = gsap.utils.mapRange(0, innerWidth, -1, 1);
        getPercentX = gsap.utils.mapRange(0, innerWidth, -1, 1);
    }

    window.addEventListener("mousemove", e => {
        xTo(e.clientX);
        yTo(e.clientY);
        const percentY = getPercentY(e.clientY);
        brandRotY(percentY * maxRot);
    });

    navbar_brand.addEventListener("mouseenter", hover_navbar_brand);
    navbar_brand.addEventListener("mouseleave", unhover_navbar_brand);

    nav_item.forEach((nav) => {

        function hover_nav_item() {
            timeLine.to(nav, 0.1, {
                scale: 1.1,
                ease: "power4.in",
                fontWeight: "bold"
            });
        }

        function unhover_nav_item() {
            timeLine.to(nav, 0.1, {
                scale: 1,
            });
        }
        nav.addEventListener("mouseenter", hover_nav_item);
        nav.addEventListener("mouseleave", unhover_nav_item);
    })

    nav_sosmed.forEach((sosmed) => {

        function hover_nav_item() {
            timeLine.to(sosmed, 0.1, {
                scale: 1.1,
                ease: "sine.in",

            });
        }

        function unhover_nav_item() {
            timeLine.to(sosmed, 0.1, {
                scale: 1,
            });
        }
        sosmed.addEventListener("mouseenter", hover_nav_item);
        sosmed.addEventListener("mouseleave", unhover_nav_item);
    })



    window.addEventListener("resize", resize);
    resize();
}

