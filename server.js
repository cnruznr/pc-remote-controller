const express = require("express");
const cors = require("cors");
const { exec } = require("child_process");

const app = express();
app.use(express.json());
app.use(cors());

app.get("/", (req, res) => {
    res.send("PC Remote Controller is running.");
});

// Bilgisayarı kapat
app.post("/shutdown", (req, res) => {
    exec("shutdown /s /f /t 0", (err) => {
        if (err) return res.status(500).send("Hata!");
        res.send("Bilgisayar kapatılıyor...");
    });
});

// Restart
app.post("/restart", (req, res) => {
    exec("shutdown /r /f /t 0", (err) => {
        if (err) return res.status(500).send("Hata!");
        res.send("Bilgisayar yeniden başlatılıyor...");
    });
});

const port = process.env.PORT || 3000;
app.listen(port, () => console.log("Server çalışıyor: " + port));
