# ColossusBets-Calculator-Test

Test project for ColossusBets company

The project is structured in three layers:

- Web Api
- Service
- Data Service (DAL)

The DAL is realized using Entity Framework 6.1.x because having only model to manage is the fastest and easyest way to do it.
By default configuration the project uses an .mdf database to store and retreive the information to avoid any problematic that different environments could create.
As IoC container is used Castle Winsdor injected in the Web Api.
For unit tests are used the libraries NUnit3 and Moq to test some functionality of the service layer.
