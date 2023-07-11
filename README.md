# test-automation-with-selenium
The script is written in C# using the Selenium WebDriver library. It utilizes the browser automation capabilities of Selenium to interact with the N11 website. The following steps are performed by the script:

Connects to the N11 website by launching a web browser and navigating to the URL.
Logs in to the website using the provided credentials or through an automated login process.
Searches for the desired product by entering the search query in the search field and submitting the search.
Selects the product from the search results based on certain criteria such as relevance or popularity.
Adds the selected product to the cart by clicking on the appropriate buttons or elements.
Navigates to the cart page to view the added product and retrieve its price.
Retrieves the product price from the cart page using DOM manipulation or element identification techniques.
Prints the product price on the console screen for immediate display.
Writes the product price to a text file for future reference or analysis.
The script incorporates appropriate waiting periods or delays using the Thread.Sleep() method to ensure that the webpage elements load properly before interacting with them. It also includes error handling mechanisms to handle any exceptions or failures that may occur during the automation process.

Requirements
To run this script, you need to have the following components installed:

Selenium WebDriver (C# bindings)
A compatible web browser (e.g., Google Chrome)
Visual Studio (or any other suitable C# development environment)
Usage
Clone the GitHub repository to your local machine.
Open the project in Visual Studio or your preferred C# development environment.
Configure the script with your N11 account credentials or automate the login process.
Build and run the script.
Observe the console output for the product price.
Check the generated text file for the recorded product price.
