# How to Use  

### 1. Create a Company Account  
Start by creating a company account on the generator app.  

### 2. Configure Your Generated App Settings  
Define the basic configurations for your app:  
- Enable/disable Google Authentication.  
- Enable/disable notifications.  
- Set the primary color for your app theme.  
- Etc.  

### 3. Add DLL Paths  
Specify the paths to the DLL files that your app will use. These files will provide the required references during generation.  

### 4. Specify Entities for Parsing  
Identify the DLLs and namespaces containing entities that the generator should parse.  

### 5. Generate App Structure (Backend + Frontend)  
Click the **"Generate Backend and Frontend Structure"** button to produce the frontend and backend structure. The generator will create:  
- **Backend:** A .NET solution with preconfigured layers.  
- **Frontend:** An Angular project with basic setup.  

### 6. Open the Backend Solution  
Navigate to the generated backend folder and open the `.sln` file.  

### 7. Add Entities to the Backend  
- Place your entities in the `Entities` folder inside the **Business** project.  
- Follow the specific **Entity Writing Rules** to ensure compatibility. (More details on attributes and rules are provided below.)  
- Use attributes to describe the system requirements and relationships for proper generation.  

### 8. Customize and Build  
- Make additional customizations to the generated structure as needed.  
- Run the solution and test your generated app.  

---

# Entity Writing Rules  
**Coming Soon:** Detailed guidelines on how to structure your entities and use attributes effectively.  

---

# Notes  
Feel free to contribute to this repository or raise issues in the GitHub Issue Tracker.  
