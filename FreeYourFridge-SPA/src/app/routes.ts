import {Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {ContactComponent} from './contact/contact.component';
import {MyProfileComponent} from './member/myProfile/myProfile.component';
import {FridgeComponent} from './fridge/fridge.component';
import {RecipesComponent} from './recipes/recipes.component';
import {FavouredComponent} from './favoured/favoured.component';
import {AuthGuard} from './_guards/auth.guard';
import {ShoppingListComponent} from './shoppingList/shoppingList.component';
import {DailyMealComponent} from './dailyMeal/dailyMeal.component';
import {MemberEditComponent} from './member/member-edit/member-edit.component';
import {MemberEditResolver} from './_resolvers/member-edit.resolver';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'contact', component: ContactComponent},
    {
        path: '', 
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'myProfile', component: MyProfileComponent, resolve: {user: MemberEditResolver}},
            {path: 'member/edit', component: MemberEditComponent, resolve: {user: MemberEditResolver}},
            {path: 'fridge', component: FridgeComponent},
            {path: 'recipes', component: RecipesComponent},
            {path: 'favoured', component: FavouredComponent},
            {path: 'shoppingList', component: ShoppingListComponent},
            {path: 'dailyMeal', component: DailyMealComponent},
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'},
];

