import{Routes} from '@angular/router';
import{HomeComponent} from './home/home.component';
import{ContactComponent} from './contact/contact.component';
import{FridgeComponent} from './fridge/fridge.component';
import{RecipesComponent} from './recipes/recipes.component';
import{FavouredComponent} from './favoured/favoured.component';
export const appRoutes: Routes = [
    {path: 'home', component: HomeComponent},
    {path: 'contact', component: ContactComponent},
    {path: 'fridge', component: FridgeComponent},
    {path: 'recipes', component: RecipesComponent},
    {path: 'favoured', component: FavouredComponent},
    {path: '**', redirectTo: 'home', pathMatch: 'full'},
];

