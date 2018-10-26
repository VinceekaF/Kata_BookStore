import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Book } from './Book';


@Injectable({
  providedIn: 'root'
})
export class CartService {

  private headers: HttpHeaders;
  private accessPointUrl = 'https://localhost:44367/api/Cart';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      return of(result as T);
    };
  }

    public addABookToCart(book: Book) {
      console.log(book);
      const url = `${this.accessPointUrl}/AddBookToCart`;
      this.http.post<Book>(url, book, {headers: this.headers});
    }
}
