function SetLimit() {
    let num = document.getElementById("limitInput").value || 50;

    window.location = "https://localhost:7246/Numbers/Limit?limit=" + num;
}