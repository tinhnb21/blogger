import { Component, OnDestroy, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { Subject, takeUntil } from 'rxjs';
import {
  AdminApiRoyaltyApiClient,
  RoyaltyReportByUserDto,
} from '../../../api/admin-api.service.generated';
import { AlertService } from '../../../shared/services/alert.service';
import { MessageConstants } from '../../../shared/constants/messages.constant';

@Component({
  selector: 'app-royalty-user',
  templateUrl: './royalty-user.component.html',
})
export class RoyaltyUserComponent implements OnInit, OnDestroy {
  //System variables
  private ngUnsubscribe = new Subject<void>();
  public blockedPanel: boolean = false;
  public items: RoyaltyReportByUserDto[] = [];
  public userName: string = '';
  public fromMonth: number = 1;
  public fromYear: number = new Date().getFullYear();
  public toMonth: number = 12;
  public toYear: number = new Date().getFullYear();
  constructor(
    private RoyaltyApiClient: AdminApiRoyaltyApiClient,
    public dialogService: DialogService,
    private alertService: AlertService,
    private confirmationService: ConfirmationService
  ) {}

  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }

  ngOnInit() {
    this.loadData();
  }

  onInput(event: any) {
    let value = event.target.value;
    value = value.replace(/\D/g, '');
    if (value.startsWith('0')) {
      value = value.substring(1);
    }
    event.target.value = value;
  }

  loadData() {
    this.toggleBlockUI(true);
    this.RoyaltyApiClient.getRoyaltyReportByUser(
      this.userName,
      this.fromMonth,
      this.fromYear,
      this.toMonth,
      this.toYear
    )
      .pipe(takeUntil(this.ngUnsubscribe))
      .subscribe({
        next: (response: RoyaltyReportByUserDto[]) => {
          this.items = response;
          this.toggleBlockUI(false);
        },
        error: () => {
          this.toggleBlockUI(false);
        },
      });
  }
  payForUser(userId: string) {
    this.confirmationService.confirm({
      message: 'Bạn có chắc muốn thanh toán?',
      accept: () => {
        this.payConfirm(userId);
      },
    });
  }

  payConfirm(id: string) {
    this.toggleBlockUI(true);

    this.RoyaltyApiClient.payRoyalty(id).subscribe({
      next: () => {
        this.alertService.showSuccess(MessageConstants.UPDATED_OK_MSG);
        this.loadData();
        this.toggleBlockUI(false);
      },
      error: () => {
        this.toggleBlockUI(false);
      },
    });
  }
  private toggleBlockUI(enabled: boolean) {
    if (enabled == true) {
      this.blockedPanel = true;
    } else {
      setTimeout(() => {
        this.blockedPanel = false;
      }, 1000);
    }
  }
}
