# Shipment tracker
## ❓ Description

Shipment Tracker is a shipment tracking application, that allows users to add, edit, view and delete shipment information.

## 🛠️ Steps to Run the Application

To run the application, follow the steps below:

1. **Clone the Repository**:
   - Start by cloning the repository to your local machine using the following command:
     ```bash
     git clone https://github.com/svetozarzvkvc/shipment-tracker.git
     ```
    - Or, you can download the repository as a ZIP file by clicking the "Code" button on the GitHub repository page and selecting "Download ZIP."

2. **Open the Solution in Visual Studio**:
   - Open the solution file (`ShipmentTracker.sln`) in Visual Studio or Visual Studio Code.

3. **Set Multiple Start Projects**:
   - In Visual Studio, go to the **Solution Explorer**.
   - Right-click on the solution name and select **Properties**.
   - Under **Common Properties**, select **Startup Project**.
   - Choose the option **Multiple startup projects**.
   - Set both the **API project** and **UI project** to **Start** by selecting **Start** in the dropdown for each.
   - Ensure both projects are configured to run together.

4. **Build and Run the Solution**:
   - Press `F5` to build and run the application or click the green start button at the top of the window.
   - This will start both the backend (API) and frontend (Blazor WASM) projects.

5. **Access the Application**:
   - Once the solution is running, open a web browser and go to `https://localhost:7170/` or the appropriate URL for your setup.

## 📂 Project Structure

The project follows the structure below:

- **API Project**: Backend logic and API endpoints.
  - `Controllers/`: API controllers for handling requests.
  - `wwwroot/`: Static files like images or JavaScript files (if needed).

- **Application Project**: Application's core business logic
  - `DTO/`: Data Transfer Objects (DTOs), which are simple objects used for transferring data between layers.
  - `Exceptions/`: Custom exceptions and error handling logic.
  - `UseCases/`: Interfaces and classes that define the specific use cases.

- **Domain Project**: Contains the entities that represent the core objects of the system.

- **Infrastructure Project**: Provides all the necessary infrastructure components.
  - `DataAccess/`: Contains the implementation of repositories and data access logic.
  - `UseCases/`: Implementation of usecases from Application layer.
  - `Validators/`: Validators for incoming data.

- **UI Project (Blazor WASM)**: Frontend logic and user interface.
  - `Pages/`: Blazor pages that define the UI.
  - `Components/`: Reusable Blazor components.
  - `wwwroot/`: Static files related to the frontend, like CSS and JavaScript.

## 🌟 Technologies and Libraries Used

- **.NET**: Backend framework used for building the API.
- **Blazor WASM**: Frontend framework for building interactive web applications.
- **FluentValidation**: A library for validating user input and ensuring data integrity.
- **Swagger**: Used for API documentation and testing.
- **Serilog**: A logging library used for tracking actions within the application, such as adding or deleting shipments. Logs are written to both the console and log files.

## 🧪 Testing the Functionalities

1. **Testing the API**:
   - Open the Swagger UI by navigating to `http://localhost:5001` in your browser.
   - The Swagger UI will display a list of all available API endpoints.
   - Each endpoint is documented with details on the expected inputs, responses, and how the request should be structured.
   - Test each endpoint by providing necessary inputs and checking the responses.

2. **Testing the Frontend**:
   - When the user opens the homepage, all available shipments are displayed.
   - Users can filter shipments by name of the shipment or by status from the form on top of the page, shipments will then be written out dynamically.
   - Read detailed info about shipment when clicking on the details button.
   - Delete a shipment by clicking the delete button.
   - Add new shipment or edit the existing one by using appropriate form.
   - After add, delete and edit actions user is notified by message that disappears after 3 seconds.
