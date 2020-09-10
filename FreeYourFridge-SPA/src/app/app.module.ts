import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import {RouterModule} from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';

import {AuthService} from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { FooterComponent } from './footer/footer.component';
import { ContactComponent } from './contact/contact.component';
import {appRoutes} from './routes';
import {ErrorInterceptorProvider} from './_services/error.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { FridgeComponent } from './fridge/fridge.component';
import { RecipesComponent } from './recipes/recipes.component';
import { FavouredComponent } from './favoured/favoured.component';
import { MyProfileComponent } from './member/myProfile/myProfile.component';
import { ShoppingListComponent } from './shoppingList/shoppingList.component';
import { DailyMealComponent } from './dailyMeal/dailyMeal.component';
import {MemberEditComponent} from './member/member-edit/member-edit.component';
import { AlertifyjsService } from './_services/alertifyjs.service';
import { AuthGuard } from './_guards/auth.guard';
import { UserService } from './_services/user.service';
import {MemberEditResolver} from './_resolvers/member-edit.resolver';
import {PreventUnsavedChanges} from './_guards/prevent-unsaved-changes.guard';

export function tokenGetter(){
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [												
    AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      FooterComponent,
      ContactComponent,
      FridgeComponent,
      RecipesComponent,
      FavouredComponent,
      MyProfileComponent,
      ShoppingListComponent,
      DailyMealComponent,
      MemberEditComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:5000'],
        disallowedRoutes: ['localhost:5000/api/auth']
      }
    })
  ],
  providers: [
    ErrorInterceptorProvider,
    AuthService,
    AlertifyjsService,
    AuthGuard,
    UserService,
    MemberEditResolver,
    PreventUnsavedChanges
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
