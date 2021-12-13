# MAUI---CleanArchitecture
MAUI application template following the principles of Clean Architecture

WORK CURRENTLY IN PROGRESS



https://user-images.githubusercontent.com/24684337/145751149-eea4dc3e-5168-4d3b-b373-2ea9b02e18b7.mp4


# Technologies
- [.NET 6 MAUI](https://github.com/dotnet/maui)
- [Entity Framework Core 6](https://docs.microsoft.com/en-us/ef/core/)
- [MediatR](https://github.com/jbogard/MediatR)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://fluentvalidation.net/)
- [Aspnet Identity authentication with SQLite database](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio)

# Description

 This is sample EShop app. It retrieves data from [Fake Store API](https://fakestoreapi.com/) once, stores it into local SQLite database, consequent times it takes only from local storage. ASPNet Identity authentication used to create new user and sign in.
 
 
Keep {viewname}**View** {viewModelName}**ViewModel** naming conventions, as assembly scanners from ViewModelLocator will be able to locate and assign BindingContext to it's view. Also on some views don't forget to add

```
<ContentPage x:Class="MAUI.CleanArchitecture.Views.LoginPageView"
             xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
           **xmlns:viewModelBase="clr-namespace:MAUI.CleanArchitecture.ViewModels.Base"
             viewModelBase:ViewModelLocator.AutoWireViewModel="True"**
             xmlns:controls="clr-namespace:MAUI.CleanArchitecture.Controls"
             xmlns:local="clr-namespace:MAUI.CleanArchitecture.Views"
             Title="Login"
             BackgroundColor="White">
	<ContentPage.Content>
		.....
	</ContentPage.Content>
</ContentPage>
```
