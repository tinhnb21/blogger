import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';

import { IconSetService } from '@coreui/icons-angular';
import { iconSubset } from './icons/icon-subset';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  template:
    '<p-toast position="top-right"></p-toast><p-confirmDialog acceptButtonStyleClass="p-button-danger p-button-text b-r-4 h-32" rejectButtonStyleClass="p-button-text p-button-text b-r-4 h-32" acceptIcon="none" rejectIcon="none" header="Xác nhận" acceptLabel="Có" rejectLabel="Không" icon="pi pi-exclamation-triangle"></p-confirmDialog><router-outlet></router-outlet>',
})
export class AppComponent implements OnInit {
  title = 'Admin UI';

  constructor(
    private router: Router,
    private titleService: Title,
    private iconSetService: IconSetService
  ) {
    titleService.setTitle(this.title);
    // iconSet singleton
    iconSetService.icons = { ...iconSubset };
  }

  ngOnInit(): void {
    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
        return;
      }
    });
  }
}
