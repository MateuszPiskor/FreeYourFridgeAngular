export interface Pagination {
  currentPage: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
}

export class PaginationResult<T> {
  result: T;
  pagination: Pagination;
}
