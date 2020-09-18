import { Component, OnInit } from '@angular/core';
import { AlertifyjsService } from '../_services/alertifyjs.service';
import { ShoppingListService } from '../_services/shoppingList.service';
import { ToDoItem } from '../_models/toDoItem';

@Component({
  selector: 'app-shoppingList',
  templateUrl: './shoppingList.component.html',
  styleUrls: ['./shoppingList.component.scss'],
})
export class ShoppingListComponent implements OnInit {
  toDoItems: ToDoItem[];
  constructor(
    private shoppingList: ShoppingListService,
    private alertify: AlertifyjsService
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
}
