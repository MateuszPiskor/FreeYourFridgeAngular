import {Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {ContactComponent} from './contact/contact.component';
import {MyProfileComponent} from './member/myProfile/myProfile.component';
import {FridgeComponent} from './fridge/fridge.component';
import {AuthGuard} from './_guards/auth.guard';
import {ShoppingListComponent} from './shoppingList/shoppingList.component';
import {DailyMealComponent} from './dailyMeal/dailyMeal.component';
import {MemberEditComponent} from './member/member-edit/member-edit.component';
import {MemberEditResolver} from './_resolvers/member-edit.resolver';
import {FridgeResolver} from './_resolvers/fridge.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { RecipeListComponent } from './recipes/recipe-list/recipe-list.component';
import { RecipeDetailComponent } from './recipes/recipe-detail/recipe-detail.component';
import { FavouredListComponent } from './favoured/favoured-list/favoured-list.component';
import {AddIngredientComponent} from './addIngredient/addIngredient.component';
import {IngredientResolver} from './_resolvers/ingredient.resolver';
import { DailyMealDetailsComponent } from './dailyMeal/daily-meal-details/daily-meal-details.component';
import { RegisterComponent } from './register/register.component';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'contact', component: ContactComponent},
    {path: 'register', component: RegisterComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'myProfile', component: MyProfileComponent, resolve: {user: MemberEditResolver}},
            // tslint:disable-next-line: max-line-length
            {path: 'member/edit', component: MemberEditComponent, resolve: {user: MemberEditResolver}, canDeactivate: [PreventUnsavedChanges]},
            {path: 'favoured', component: FavouredListComponent},
            {path: 'fridge', component: FridgeComponent, resolve: {fridge: FridgeResolver}},
            {path: 'addIngredient', component: AddIngredientComponent, resolve: {ingredient: IngredientResolver}},
            {path: 'recipes', component: RecipeListComponent},
            {path: 'shoppingList', component: ShoppingListComponent},
            {path: 'dailyMeal', component: DailyMealComponent},
            {path: 'dailyMeal/:id', component: DailyMealDetailsComponent},
            { path: 'recipes/:id', component: RecipeDetailComponent }
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'},
    ];
