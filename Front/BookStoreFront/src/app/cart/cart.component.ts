import { Component, OnInit } from '@angular/core';
import { CartService } from '../cart.service';
import { Router } from '@angular/router';
import { Book } from '../Book';
import { MatSnackBar } from '@angular/material';


@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  totalPrice = 0;
  currentListOfBooks: Book[] = [];

  constructor(
    private cartService: CartService,
    private router: Router,
    ) { }

  ngOnInit() {
    this.cartService.getTotalPrice().subscribe(data => this.totalPrice = data);
    this.cartService.getCurrentCartList().subscribe(b => this.currentListOfBooks = b);
  }

  goToWelcomePage() {
    this.router.navigate(['/welcome']);
  }

  submitCart() {

  }

}
