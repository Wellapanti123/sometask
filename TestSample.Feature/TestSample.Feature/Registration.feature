Public Class Registration
Feature: Application Registration
As an Authenticated user
I should be able to register website

#Can be automated
Scenario: Landing Page Registration
Given Landing Page with Email Address Field
And register button to register for a user on website
When User clicks on Register button with blank  email address.
Then It should throw error message.

#Can be automated
Scenario: Registeration button on landing page throws error with Invalid email address
Given Email text field and Register Button on Landing Page
When User Provide Invalid Email 
And Clicks on Register Button
Then It should throw error on landing page for invalid error message.

#Can be automated
Scenario: Registeration button on Landing Page redirects user to registeration Page with Valid Email Address
Given Email text field and Register Button on Landing Page
When User Provide Valid Email 
And Clicks on Register Button
Then User Redirects to Registration Page

#Can be automated
Scenario: On Registeration Page word limit is applied for nickname field
Given A Nickname field
When User fill the nickname with Less then 3 or more then 13 character
Then It should throw error "Your nickname must be between 3 and 13 characters long. Your nickname may not contain Cyrillic letters or special characters."

#Cannot be automated as it consist of captcha, this scenario during API automation
Scenario: On Registeration Page User should be able to register the email with valid details
Given An email, nickname, password, date of birth, I agree, Captcha and begin adventure button
When User fill the registration form with valid details
Then User should be able to register the application.

#Cannot be automated as it consist of captcha, this scenario during API automation
Scenario: On Registeration Page, Application should throw error with Invalid email
Given An email, nickname, password, date of birth, I agree, Captcha and begin adventure button
When User fill the registration form with Invalid email
Then User should be able to see error for Invalid email.

#Can be automated
Scenario: Login button on Landing Page redirects user to Login Page
Given Login Button on Landing Page
When User Clicks on Login Button
Then User Redirects to Login Page

#Can be automated
Scenario: User is able to Login inside application with valid credentials
Given Login Page with Nickname, Password and Log In Button
When User fills login details with valid credentials
Then User should redirect to application Home Page

#Can be automated
Scenario: User should see error with Invalid login credentials on login page
Given Login Page with Nickname, Password and Log In Button
When User Fills Login Details with Invalid credentials
Then It should throw error

#Can be automated
Scenario: User should navigate to forgot you password field from login page
Given Forgotten your password link on login page
When User clicks on Forgotten your password
Then User should be navigated to Forgot your password page.

End Class
