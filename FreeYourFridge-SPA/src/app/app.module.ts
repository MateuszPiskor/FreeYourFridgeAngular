import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { RouterModule } from '@angular/router';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { FooterComponent } from './footer/footer.component';
import { ContactComponent } from './contact/contact.component';
import { appRoutes } from './routes';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { FridgeComponent } from './fridge/fridge.component';
import { FavouredComponent } from './favoured/favoured.component';
import { MyProfileComponent } from './myProfile/myProfile.component';
import { ShoppingListComponent } from './shoppingList/shoppingList.component';
import { DailyMealComponent } from './dailyMeal/dailyMeal.component';
import { RecipeListComponent } from './recipes/recipe-list/recipe-list.component';
import { RecipeCardComponent } from './recipes/recipe-card/recipe-card.component';
import { RecipeDetailComponent } from './recipes/recipe-detail/recipe-detail.component';
import { RecipeInstructionComponent } from './recipes/recipe-instruction/recipe-instruction.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    FooterComponent,
    ContactComponent,
    FridgeComponent,
    RecipeListComponent,
    RecipeCardComponent,
    FavouredComponent,
    MyProfileComponent,
    ShoppingListComponent,
    DailyMealComponent,
    RecipeDetailComponent,
    RecipeInstructionComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    RouterModule.forRoot(appRoutes),
  ],
  providers: [ErrorInterceptorProvider, AuthService],
  bootstrap: [AppComponent],
})
export class AppModule {}
