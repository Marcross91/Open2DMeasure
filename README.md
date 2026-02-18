![Open2DMeasure_Logo](https://github.com/user-attachments/assets/e74e2806-bd23-49b3-b82d-002df3fa578a)
Open2DMeasure
Open2DMeasure is a lightweight Windows-based desktop application dedicated to 2D dimensional metrology. The software enables users to analyze technical images, perform precise geometric measurements, and manage industrial tolerances through a simple and intuitive interface.

Designed for metrologists, quality control inspectors, and engineers who need an open-source tool for rapid component verification.

🚀 Key Features
1. Geometric Entity Management
The software allows the creation and management of fundamental entities:

Points, Lines and Circle: Define points in the 2D image and construct other entities in the construction page.

Construction Tools: Create derived geometries such as intersections and midpoints and so on.

Measurement: Define distances, diameters, radii or angles in a quick way.


2. Tolerance System
Every measurement can be assigned specific acceptability limits:

Bilateral Tolerances: Easily set Upper Tolerance, Lower Tolerance and nominal value via a quick-access context menu directly with right click on the measurements list.

Real-time Status Calculation: Automatic evaluation of the measurement state (OK/KO) based on the deviation from the nominal value.


3. Professional Reporting (CSV Export)
Automatically generate reports ready for archiving or advanced analysis in Excel/PowerBI:

Dynamic Headers: Includes Part Code, Description, Metrologist Name, and Timestamp.

Data Consistency: Exports Entity Type, Name, Nominal Value, Tolerances, Measured value and Final Status.


4. Modern & Responsive UI
Adaptive Layout: Utilizes TableLayoutPanel and FlowLayoutPanel to ensure readability across various screen resolutions.

Logical Organization: Commands are grouped by function: Alignment, Construction, and Measurement.

Professional Branding: Integrated logo and "Info" section containing versioning and authorship metadata.

🛠 Technical Specifications
Language: C#

Framework: .NET Framework / WinForms

Architecture: Object-Oriented Programming (OOP) for geometric class management.

License: MIT (Open Source)

📖 Getting Started
Prerequisites
Windows 10 or higher.

.NET Framework installed.



QUICK START INSTRUCTION

1) Load Image: Import the photo or screenshot of the part to be measured.
   <img width="1918" height="1025" alt="Main page" src="https://github.com/user-attachments/assets/8d31b635-760b-48ff-b06f-037d5416041c" />


2) Calibrate: 1. Set the ratio calculation method in the listbox:
		a) Known distance: if you know the distance between 2 point of the image you can click the 2 point and enter the real value (ratio is calculated automatically)
		b) Known horizontal distance: if you know the horizontal distance between 2 point of the image you can click the 2 point and enter the real value (ratio is calculated automatically)
		c) b) Known vertical distance: if you know the vertical distance between 2 point of the image you can click the 2 point and enter the real value (ratio is calculated automatically)
<img width="243" height="137" alt="Ratio calibration" src="https://github.com/user-attachments/assets/c50b4c95-a4eb-4211-89e9-f75cb892e4c3" />

	   2. ***** In progress *****

3) Create points: Click on the image to create points.

4) Construct derived entities: Construct entities by using the Construction command group
<img width="1917" height="1030" alt="Construction" src="https://github.com/user-attachments/assets/1797c97e-d2c7-42d4-9cfe-783738d04505" />

5) Align: Set the zero point by using the Alignment command group

6) Measure: Measure distance, diameter, radii and angle by using the Measurement command group

7) Set Tolerances: Right-click on the element list to define limits and nominal values.

8) Generate Report: Click "Generate Report" to save results as a CSV file.

9) You can save your work with the "Save" button

📄 License
This project is licensed under the MIT License. See the LICENSE file for details.

👥 Author
Developer: [Marco Porporato]

Current Version: [1.0.0]

<img width="687" height="433" alt="Info" src="https://github.com/user-attachments/assets/47c441ca-8348-4c84-a1e6-19702f433c61" />



Purpose of NEXT MAJOR RELEASE:
- Eng language application
- Receiving image from a fixed camera (New type of calibration will be used)
