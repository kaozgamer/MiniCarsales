[![LinkedIn][linkedin-shield]][linkedin-url]



<p align="center">

  <h3 align="center">Mini Carsales</h3>

  <p align="center">
    Vehicle management system that will initially only cater for cars.
  </p>
</p>



<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Contact](#contact)



<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][product-screenshot]](https://example.com)

This solution currently supports adding a car and viewing all cars currently saved in memory.

Here is a summary of the design decisions I took:
* `Vehicle` is a base class that `Car` inherits from - any new vehicles in the future can inherit from `Vehicle`.
  * Both these classes contain validations attributes on the properties that is validated by the controller (in addition to the client side validation).
* `IVehicleService` is the service that the controller calls to perform CRUD operations on the vehicles stored in memory.
  * As per the requirements, all vehicles are simply stored in a list in memory - I choose this as it's the easiest and I have designed the service in a way that it can be easily pointed at a database, if one existed.
  * This service has been added as a singleton so that it retains the list of vehicles between client calls - again this was done because vehicles are not persisted to a database.
* On the client side I have a `add-car` component that extends `add-vehicle` - `add-vehicle` contains the input fields that are common to all vehicles while `add-car` contains the car specific fields. This is done so that it can be extends to accommodate more vehicle types in the future.
  * These inputs contain client side validation using Angular.
* xUnit is used to unit test the backend service and cars controller - see `CarsControllerFacts` and `VehicleServiceFacts`.


### Built With

* Angular
* .NET Core
* Bootstrap



<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* npm
```sh
npm install npm@latest -g
```
* ng
```sh
npm install -g @angular/cli
```

### Installation
 
1. Clone the repo
```sh
git clone https://github.com/github_username/repo.git
```
2. Open MiniCarsales.sln in Visual Studio
3. Build solution - Visual Studio will handle installing all the required dependencies



<!-- CONTACT -->
## Contact

Thushan Perera - thushan.perera95@gmail.com

Project Link: [https://github.com/kaozgamer/MiniCarsales](https://github.com/kaozgamer/MiniCarsales)




<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/othneildrew/Best-README-Template.svg?style=flat-square
[contributors-url]: https://github.com/othneildrew/Best-README-Template/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/othneildrew/Best-README-Template.svg?style=flat-square
[forks-url]: https://github.com/othneildrew/Best-README-Template/network/members
[stars-shield]: https://img.shields.io/github/stars/othneildrew/Best-README-Template.svg?style=flat-square
[stars-url]: https://github.com/othneildrew/Best-README-Template/stargazers
[issues-shield]: https://img.shields.io/github/issues/othneildrew/Best-README-Template.svg?style=flat-square
[issues-url]: https://github.com/othneildrew/Best-README-Template/issues
[license-shield]: https://img.shields.io/github/license/othneildrew/Best-README-Template.svg?style=flat-square
[license-url]: https://github.com/othneildrew/Best-README-Template/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/thushanperera
[product-screenshot]: images/screenshot.png
