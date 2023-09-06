let numeroAleatorio = Math.floor(Math.random() * 20) + 1;
let puntaje = 20;
let puntajeMaximo = 0;

const numeroInput = document.getElementById("numeroInput");
const intentarBtn = document.getElementById("asd");
const reiniciarBtn = document.getElementById("reset");
const mensaje = document.getElementById("mensaje");
const scoreElement = document.getElementById("score");
const highScoreElement = document.getElementById("highScore");
const trampa = document.getElementById("trampa");

intentarBtn.addEventListener("click", () => {
    const numeroUsuario = parseInt(numeroInput.value);
    trampa.textContent = numeroAleatorio


    if (isNaN(numeroUsuario) || numeroUsuario < 1 || numeroUsuario > 20) {
        mensaje.textContent = "Ingresa un número válido entre 1 y 20.";
    } else {
        
        if (numeroUsuario === numeroAleatorio) {
            mensaje.textContent = "¡Felicitaciones ganaste!";
            alert("GANASTE !!!!")

            if (puntaje > puntajeMaximo) {
                puntajeMaximo = puntaje;
            }

        } else {
            puntaje -= 2;
            if (puntaje <= 0) {
                mensaje.textContent = '¡Perdiste! El número era ${numeroAleatorio}.';
                reiniciarJuego();
            } else {
                devolverCercania(numeroUsuario, numeroAleatorio);
            }
        }
    }

    scoreElement.textContent = puntaje;
    highScoreElement.textContent = puntajeMaximo;

});

reiniciarBtn.addEventListener("click", () => {
    reiniciarJuego();
});

function reiniciarJuego() {
    puntaje = 20;

    numeroAleatorio = Math.floor(Math.random() * 20) + 1;
    mensaje.textContent = "";
    scoreElement.textContent = 20;
    trampa.textContent = numeroAleatorio
}

function devolverCercania(numeroUsuario, numeroAleatorio) {
    if (numeroUsuario + 1 === numeroAleatorio || numeroUsuario - 1 === numeroAleatorio) {
        mensaje.textContent = "ESTAS AL LADO!";
    }
    else if (numeroUsuario > numeroAleatorio) {
        mensaje.textContent = "Te pasaste";
    }
    else {
        mensaje.textContent = "Te falto un poquito";
    }
}