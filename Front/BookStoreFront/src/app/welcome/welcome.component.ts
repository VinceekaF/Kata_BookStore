import { Component, OnInit } from '@angular/core';
import { Book } from '../Book';
import { BookService } from '../book.service';
import { CartService } from '../cart.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.scss']
})
export class WelcomeComponent implements OnInit {

  books: Book[] = [];
  displayedColumns: string[] = ['Title', 'Price'];

  constructor(
    private bookService: BookService,
    private cartService: CartService
  ) { }

  ngOnInit() {
    this.bookService.getAllBooks().subscribe(b => {
      this.books = b;
      console.log(this.books);
    });
  }

  addABookToCart(bookToAdd: Book) {
    this.cartService.addABookToCart(bookToAdd).subscribe();
  }
}
