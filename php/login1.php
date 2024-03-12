<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Get the username and password from the POST request
    $username = $_POST["username"];
    $password = $_POST["password"];

    // Hash the password
    $hashed_password = md5($password);

    // Connect to the database
    $pdo = new PDO("mysql:host=localhost;dbname=databasename", "username", "password");

    // Check if the username and hashed password match a record in the database
    $stmt = $pdo->prepare("SELECT * FROM users WHERE username = ? AND password = ?");
    $stmt->execute([$username, $hashed_password]);
    $user = $stmt->fetch();

    if ($user) {
        // Login successful
        echo "Login successful";
    } else {
        // Login failed
        echo "Login failed";
    }
}
?>
