![Playwright Tests](https://github.com/Aloman28/Playwright_csharp/actions/workflows/playwright.yml/badge.svg)

### Objective

Automated test cases for an online shop to test the core functionality of the site.
Sample site is using: https://www.saucedemo.com/


### Coverage

| Site        | URL                                |
| ----------- | ---------------------------------- |
| Online Shop | https://www.saucedemo.com/         |

 Test scenarios for all provided user accounts as below:

| User                    | Description                                                             |
| ----------------------- | ----------------------------------------------------------------------- |
| standard_user           | The site should work as expected for this user                          |
| locked_out_user         | User is locked out and should not be able to log in.                    |
| problem_user            | Images are not loading for this user.                                   |
| performance_glitch_user | This user has high loading times. Does the site still work as expected? |

End to End scenario
Login -> Add Item to cart -> Pay -> Verify Success transaction


### Implementations
Tools using Playwright and Nunit
