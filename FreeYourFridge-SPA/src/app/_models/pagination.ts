export interface Pagination {
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
  totalPages: number;
}

export class PaginationResult<T> {
  result: T;
  pagination: Pagination;
  // static result: import("c:/Users/gryty/OneDrive/Pulpit/programing/codecool/codecool/Advance/ProjectZ/FreeYourFridge-SPA/src/app/_models/Favoured/favouredDto").FavouredDto[];
  // static pagination: any;
}
