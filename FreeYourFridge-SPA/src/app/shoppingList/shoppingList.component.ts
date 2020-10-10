import { Component, OnInit } from '@angular/core';
import { AlertifyjsService } from '../_services/alertifyjs.service';
import { ShoppingListService } from '../_services/shoppingList.service';
import { ToDoItem } from '../_models/toDoItem';
import { FridgeService } from '../_services/fridge.service';
import { IngredientToApi } from '../_models/ingredientToApi';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-shoppingList',
  templateUrl: './shoppingList.component.html',
  styleUrls: ['./shoppingList.component.scss'],
})
export class ShoppingListComponent implements OnInit {
  toDoItems: ToDoItem[];
  public toDoItem: ToDoItem;
  public ingredientToApi: IngredientToApi = {
    id: 0,
    Name: '',
    amount: 0,
    unit: 'g'
  };
  constructor(
    private shoppingList: ShoppingListService,
    private alertify: AlertifyjsService,
    private fridgeService: FridgeService,
    private authService: AuthService
  ) {}
  ngOnInit() {
    this.getAllToDoItems();
  }

  getAllToDoItems() {
    this.shoppingList.getToDoItems().subscribe(
      (toDoItems: ToDoItem[]) => {
        this.toDoItems = toDoItems;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  deleteTask(toDoItemId) {

    this.toDoItems = this.toDoItems.filter(i => i.spoonacularId !== toDoItemId);
    this.shoppingList.deleteToDoItems(+toDoItemId).subscribe(
      () => {
        this.alertify.success('Removed from shoplist');
      },
      (error) => {
        this.alertify.error('Some problem occur');
      }
    );
  }
  buyTask(toDoItem){
      this.ingredientToApi.id = toDoItem['spoonacularId'];
      this.ingredientToApi.Name = toDoItem['name'];
      this.ingredientToApi.amount = toDoItem['amount'];
      this.ingredientToApi.unit = toDoItem['unit'];
      this.fridgeService.addNewIngredient(this.authService.decodedToken.nameid, this.ingredientToApi).subscribe(next => {
        this.alertify.success('Ingredient add succesfully');
      }, error => {
        this.alertify.error(error);
      });
      this.deleteTask(toDoItem['spoonacularId']);
    }
}
