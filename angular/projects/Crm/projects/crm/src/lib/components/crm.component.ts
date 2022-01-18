import { Component, OnInit } from '@angular/core';
import { CrmService } from '../services/crm.service';

@Component({
  selector: 'lib-crm',
  template: ` <p>crm works!</p> `,
  styles: [],
})
export class CrmComponent implements OnInit {
  constructor(private service: CrmService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
