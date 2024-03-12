<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Validate input
    $username = $_POST["username"];
    $password = $_POST["password"];

    if (empty($username) || empty($password)) {
        echo "Please fill out all fields.";
        exit;
    }

    // Hash the password
    $hashed_password = md5($password);

    // Insert user data into the database
    // (Note: Use prepared statements to prevent SQL injection)
    $pdo = new PDO("mysql:host=localhost;dbname=datbasename", "username", "password");
    $stmt = $pdo->prepare("INSERT INTO users (username, password) VALUES (?, ?)");
    $stmt->execute([$username, $hashed_password]);

    echo "User registered successfully.";
}
?>
