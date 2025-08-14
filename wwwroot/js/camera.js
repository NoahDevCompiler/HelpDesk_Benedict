
export async function startCamera(videoElementId) {
    const video = document.getElementById(videoElementId);
    if (!video) return;

    try {
        const stream = await navigator.mediaDevices.getUserMedia({ video: true });
        video.srcObject = stream;
        await video.play();
    } catch (err) {
        console.error("Kamera konnte nicht gestartet werden:", err);
    }
}

export async function takePicture(videoElementId, imgElementId) {
    const video = document.getElementById(videoElementId);
    const img = document.getElementById(imgElementId);
    if (!video) return;

    const canvas = document.createElement('canvas');
    canvas.width = video.width;
    canvas.height = video.height;
    const ctx = canvas.getContext('2d');
    ctx.drawImage(video, 0, 0, canvas.width, canvas.height);

    img.src = canvas.toDataURL('image/png');

}
