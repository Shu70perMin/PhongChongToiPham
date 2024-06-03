# PhongChongToiPham
This site was built using [GitHub Pages](https://pages.github.com/).
phongchongtoipham.vn
PhongChongToiPham is a responsive web application focused on raising awareness and facilitating the reporting of criminal activities within communities.

## Member list
- Nguyen Thanh Kiet – 22520720
- Nguyen Thanh Hung – 22520517	
- Do Dang Hieu – 22520432	
- Phan Gia Tri – 22521527

## Mind Map

![mindmap](phongchongtoipham/wwwroot/image/mindmap.jpg)


## Features
- **Home**: Displays banner advertisements and a list of dangerous criminals.
- **About Us**: Provides information about the website and its purpose.
- **Crime Reporting**: Allows users to report criminal incidents by filling out a form.
- **News**: Showcases the latest news and updates related to criminal activities.
- **Resources**: Offers statistical charts, detailed information about crimes, and a search functionality for specific criminal cases.
- **Blog**: Shares knowledge and experiences regarding crime prevention.

## Demo
- https://phongchongtoipham.tradevn.mom

- https://www.youtube.com/watch?v=e1kR2zEzVAQ

## Technologies Used 
- **Front-end**: HTML, CSS
- **Back-end**: ASP.NET

## Set up the environment
- Download Visual Studio, in Visual Studio Installer download the ASP.NET and web development and Data storage and processing packages.

 ![image](https://github.com/Shu70perMin/PhongChongToiPham/assets/168970294/16146165-f30c-4899-9dcf-22845a10fe02)
![image](https://github.com/Shu70perMin/PhongChongToiPham/assets/168970294/64b7b32b-c076-425c-ad5e-0771b7a2e6bd)
- Run Visual Studio, select Create a new project, find and select ASP.NET Core Web App (Model-View-Controller) > Next.
- In the new project configuration section, enter a name and select the optional storage path -> Next.
- In the additional information section, select .NET 8.0 (Long Term Support)->Create.

![image](https://github.com/Shu70perMin/PhongChongToiPham/assets/168970294/b22de0c9-1452-4b3f-a9de-2820216dbd4a)

## Dependent packages
-  In which EntityFrameworkCore packages support Sql Server database linking, X.PagedList packages support paging.

![image](https://github.com/Shu70perMin/PhongChongToiPham/assets/168970294/3a4f75c7-9565-4c3a-bff4-35c154c6f587)

## Function
  **User**:
 - Login, Register (ajax)
 - Blog (displays posts, click to see detailed content)
 - Data (displays a paginated list of criminals, with a search bar by criminal name)
 - Home page (web overview)
 - Knowledge (shows basic crime fighting knowledge)
 - Test knowledge (take a quiz to test knowledge)
 - Report (fill out crime report form, send to admin for verification and approval)

 **Admin**:
 - Manage reports (display existing reports, can approve (ajax) or reject)
 - Manage accounts (show existing accounts, add, edit (ajax) or delete accounts)
 - Manage crimes (show existing crimes, add, edit (ajax) or delete crimes)
 - Manage posts (fill out form to post (ajax)) 

## Getting Started
To run the project locally, follow these steps:

1. Clone the repository: `git clone https://github.com/Shu70perMin/PhongChongToiPham`
2. Navigate to the project directory: `cd PhongChongToiPham`
3. Set up the necessary dependencies and configurations
4. Start the development server
5. Open your browser and navigate to the provided local URL

## Contributing
Contributions are welcome! 
If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.

## Find a bug ?
If you found an issue or would like to submit an improvement to this project, please submit an issue using the issue tab above. If you would like to submit a PR with a fix, reference the issue you created.

## Know issues (Work in progress)
Coming soon.
