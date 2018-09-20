<html>
<body>
<h3>Response Page</h3>
<table border='1'>

<?php
		$pdo = new PDO('mysql:dbname=a00leifo;host=localhost', 'myusername', 'mypassword');

		if(isset($_GET['SSN'])){
			
				$querystring='SELECT * FROM CUSTOMER WHERE SSN=:SSN';
				
				$stmt = $pdo->prepare($querystring);
				$stmt->bindParam(':SSN', $_GET['SSN']);
				$stmt->execute();
								     
				foreach($stmt as $key => $row){
					echo "<tr>";
					echo "<td>".$row['CUSTNO']."</td>";			
					echo "<td>".$row['NAME']."</td>";			
					echo "<td>".$row['REGDATE']."</td>";
					echo "</tr>";
				}
		}
?>

</table>
</body>
</html>

