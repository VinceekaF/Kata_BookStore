import { Component, OnInit } from '@angular/core';
import { Book } from '../Book';
import { BookService } from '../book.service';
import { CartService } from '../cart.service';
import { MatSnackBar } from '@angular/material';

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
    private cartService: CartService,
    public snackBar: MatSnackBar
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

  openSnackBar(action: string) {
    this.snackBar.open('1 book added to your cart', action, {duration: 1000});
  }
}
