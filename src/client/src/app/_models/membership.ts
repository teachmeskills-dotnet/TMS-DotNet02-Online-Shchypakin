import { MembershipHistoryRecord } from "./membershipHistoryRecord";
import { MembershipSize } from "./membershipSize";
import { MembershipType } from "./membershipType";


export interface Membership {
    id: number;
    start: Date;
    end: Date;
    membershipType: MembershipType;
    membershipSize: MembershipSize;
    visitsLeft: number;
    isActive: boolean;
    membershipHistoryRecords: MembershipHistoryRecord[];
}
