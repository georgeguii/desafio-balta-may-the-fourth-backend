const setStyle = (element, top, left) => {
    element.style.top = top + '%';
    element.style.left = left + '%';
};

const appendToBody = (element) => {
    document.body.appendChild(element);
};

const createStar = () => {
    const star = document.createElement("div");
    star.className = 'stars';

    const delay = Math.random() * 5;
    star.style.animationDelay = delay + "s";

    return star;
};

const randomPosition = () => {
    const randomX = Math.round(Math.random() * 10000) / 100;
    const randomY = Math.round(Math.random() * 10000) / 100;
    return [randomX, randomY];
};

export async function createAndPositionStars(count) {
    for (let i = 0; i < count; i++) {
        const star = createStar();
        const xy = randomPosition();
        setStyle(star, xy[0], xy[1]);
        appendToBody(star);
    }
};
