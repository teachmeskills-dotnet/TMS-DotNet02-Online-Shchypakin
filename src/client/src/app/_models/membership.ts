import { MembershipSize } from "./membershipSize";
import { MembershipType } from "./membershipType";


export interface Membership {
    id: number;
    start: Date;
    end: Date;
    membershipType: MembershipType;
    membershipSize: MembershipSize;
    isActive: boolean;
}
