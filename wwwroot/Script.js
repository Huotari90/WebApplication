function performOperation(operation) {
    const num1 = document.getElementById('num1').value;
    const num2 = document.getElementById('num2').value;
    // Corrected URL interpolation.
    const apiUrl = `https://webcalcu.azurewebsites.net/${operation}?num1=${num1}&num2=${num2}`;

    fetch(apiUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            // Ensure you're accessing the correct property of 'data' if it's an object
            document.getElementById('result').textContent = data.result ? data.result : data;
        })
        .catch(error => {
            console.error('There has been a problem with your fetch operation:', error);
            document.getElementById('result').textContent = 'Error: ' + error.message;
        });
}

