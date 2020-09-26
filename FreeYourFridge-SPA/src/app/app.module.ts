import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthService } from './_services/auth.service';
import { RecipeService } from './_services/recipe.service';
import { DealMealService } from './_services/dealMeal.service';
import { ShoppingListService } from './_services/shoppingList.service';
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
import { MyProfileComponent } from './member/myProfile/myProfile.component';
import { ShoppingListComponent } from './shoppingList/shoppingList.component';
import { DailyMealComponent } from './dailyMeal/dailyMeal.component';
import { MemberEditComponent } from './member/member-edit/member-edit.component';
import { AlertifyjsService } from './_services/alertifyjs.service';
import { AuthGuard } from './_guards/auth.guard';
import { UserService } from './_services/user.service';
import { FavouredService } from './_services/favoured.service';
import { MemberEditResolver } from './_resolvers/member-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { RecipeListComponent } from './recipes/recipe-list/recipe-list.component';
import { RecipeCardComponent } from './recipes/recipe-card/recipe-card.component';
import { RecipeDetailComponent } from './recipes/recipe-detail/recipe-detail.component';
import { RecipeInstructionComponent } from './recipes/recipe-instruction/recipe-instruction.component';
import { Data } from './data';
import { RaitingComponent } from './raiting/raiting.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RatingContentComponent } from './rating-content/rating-content.component';
import { FavouredListComponent } from './favoured/favoured-list/favoured-list.component';
import { FavouredCardComponent } from './favoured/favoured-card/favoured-card.component';

export function tokenGetter() {
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
    RecipeListComponent,
    RecipeCardComponent,
    MyProfileComponent,
    ShoppingListComponent,
    DailyMealComponent,
    RecipeDetailComponent,
    RecipeInstructionComponent,
    MemberEditComponent,
    RaitingComponent,
    RatingContentComponent,
    FavouredListComponent,
    FavouredCardComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    RouterModule.forRoot(appRoutes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:5000'],
        disallowedRoutes: ['localhost:5000/api/auth'],
      },
    }),
    NgbModule,
  ],
  providers: [
    ErrorInterceptorProvider,
    AuthService,
    AlertifyjsService,
    AuthGuard,
    UserService,
    RecipeService,
    DealMealService,
    MemberEditResolver,
    Data,
    ShoppingListService,
    PreventUnsavedChanges,
    ReactiveFormsModule,
    FavouredService,
  ],
  bootstrap: [AppComponent],
  entryComponents: [RatingContentComponent],
})
export class AppModule {}
