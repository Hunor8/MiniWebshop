const express = require('express');
const app = express();
const mysql = require('mysql2');

const PORT = 3000;
const host = 'localhost'; 

// Beállítjuk a JSON-ben érkező adatok kezelését
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

//kapcsolat beállítása az adatbázissal 
const conn = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'mini_webshop',
    timezone: 'Z'
})

// Alap route
app.get('/', (req, res) => {
  res.send('Node.js szerver működik!');
});

// összes termék lekérdezése
app.get('/products', (req, res) => {
    conn.query('SELECT * FROM products', (err, result) => {
        if (err) {
            console.log(err);
            return res.status(500).json({ error: 'Hiba a lekérdezés során!' });
        }

        if (result.length === 0) {
            return res.status(404).json({ error: 'Nem található!' });
        }

        return res.status(200).json(result);
    });
});

app.post('/products', (req, res) => {
    const { name, price, category, inStock } = req.body;

    const sql = 'INSERT INTO products (name, price, category, inStock) VALUES (?, ?, ?, ?)';
    conn.query(sql, [name, price, category, inStock], (err, result) => {
        if (err) {
            console.log(err);
            return res.status(500).json({ error: 'Hiba beszúráskor!' });
        }

        return res.status(201).json({ message: 'Sikeres hozzáadás!' });
    });
});

app.put('/products/:id', (req, res) => {
    const id = req.params.id;
    const { name, price, category, inStock } = req.body;

    const sql = 'UPDATE products SET name=?, price=?, category=?, inStock=? WHERE id=?';
    conn.query(sql, [name, price, category, inStock, id], (err, result) => {
        if (err) {
            console.log(err);
            return res.status(500).json({ error: 'Hiba módosításkor!' });
        }

        return res.status(200).json({ message: 'Sikeres módosítás!' });
    });
});

app.delete('/products/:id', (req, res) => {
    const id = req.params.id;

    const sql = 'DELETE FROM products WHERE id=?';
    conn.query(sql, [id], (err, result) => {
        if (err) {
            console.log(err);
            return res.status(500).json({ error: 'Hiba törléskor!' });
        }

        return res.status(200).json({ message: 'Sikeres törlés!' });
    });
});
// Szerver indítása
app.listen(PORT, () => {
    console.log(`Szerver fut: http://${host}:${PORT}`);
  });