import axios from "axios";

export const LerConteudoDaImagem = async (formData) => {

    let resultado;

    let retorno = await axios({
        method: "POST",
        url: "https://ocr-techman.cognitiveservices.azure.com/vision/v3.2/ocr?language=unk&detectOrientation=true&model-version=latest",
        data: formData,
        headers: {
            "Content-Type" : "multipart/form-data",
            "Ocp-Apim-Subscription-Key" : "e6b6b3fb9aac49cc943b7cf4cbfa5a94"
        }
    })
    .then(response => {
        console.log(response)
        resultado = lerJSON(response.data);
    })
    .catch(erro => console.log(erro))

    return resultado;

}

export const lerJSON = (obj) => {


    let resultado;

    obj.regions.forEach(regions => {
        regions.lines.forEach(lines => {
            lines.words.forEach(words => {
                if (words.text[0] === "1" && words.text[1] === "2") {
                    resultado = words.text;
                }
            });
        });
    });

    return resultado;

}