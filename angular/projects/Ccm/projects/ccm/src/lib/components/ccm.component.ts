import { Component, OnInit } from '@angular/core';
import { CcmService } from '../services/ccm.service';

@Component({
  selector: 'lib-ccm',
  template: ` <p>ccm works!</p> `,
  styles: [],
})
export class CcmComponent implements OnInit {
  constructor(private service: CcmService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
