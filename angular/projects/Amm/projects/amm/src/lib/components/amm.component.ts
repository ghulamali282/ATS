import { Component, OnInit } from '@angular/core';
import { AmmService } from '../services/amm.service';

@Component({
  selector: 'lib-amm',
  template: ` <p>amm works!</p> `,
  styles: [],
})
export class AmmComponent implements OnInit {
  constructor(private service: AmmService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
