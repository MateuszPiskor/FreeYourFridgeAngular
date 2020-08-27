import {Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {ContactComponent} from './contact/contact.component';
import {MyProfileComponent} from './myProfile/myProfile.component';
import {FridgeComponent} from './fridge/fridge.component';
import {RecipesComponent} from './recipes/recipes.component';
import {FavouredComponent} from './favoured/favoured.component';
import {AuthGuard} from './_guards/auth.guard';
import {ShoppingListComponent} from './shoppingList/shoppingList.component';
import {DailyMealComponent} from './dailyMeal/dailyMeal.component';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'contact', component: ContactComponent},
    {
        path: '', 
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'myProfile', component: MyProfileComponent},
    {path: 'fridge', component: FridgeComponent},
    {path: 'recipes', component: RecipesComponent},
    {path: 'favoured', component: FavouredComponent},
    {path: 'shoppingList', component: ShoppingListComponent},
    {path: 'dailyMeal', component: DailyMealComponent},
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'},
];

