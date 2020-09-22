import {Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {ContactComponent} from './contact/contact.component';
import {MyProfileComponent} from './member/myProfile/myProfile.component';
import {FridgeComponent} from './fridge/fridge.component';
import {FavouredComponent} from './favoured/favoured.component';
import {AuthGuard} from './_guards/auth.guard';
import {ShoppingListComponent} from './shoppingList/shoppingList.component';
import {DailyMealComponent} from './dailyMeal/dailyMeal.component';
import {MemberEditComponent} from './member/member-edit/member-edit.component';
import {MemberEditResolver} from './_resolvers/member-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { RecipeListComponent } from './recipes/recipe-list/recipe-list.component';
import { RecipeDetailComponent } from './recipes/recipe-detail/recipe-detail.component';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'contact', component: ContactComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'myProfile', component: MyProfileComponent, resolve: {user: MemberEditResolver}},
            // tslint:disable-next-line: max-line-length
            {path: 'member/edit', component: MemberEditComponent, resolve: {user: MemberEditResolver}, canDeactivate: [PreventUnsavedChanges]},
            {path: 'fridge', component: FridgeComponent, resolve: {user: MemberEditResolver}},
            {path: 'favoured', component: FavouredComponent},
            {path: 'recipes', component: RecipeListComponent},
            {path: 'shoppingList', component: ShoppingListComponent},
            {path: 'dailyMeal', component: DailyMealComponent},
            { path: 'recipes/:id', component: RecipeDetailComponent }
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'},
    ];
