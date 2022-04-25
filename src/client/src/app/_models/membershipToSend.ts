export interface MembershipToSend {
    clientId: number;
    start: Date;
    end: Date;
    online: boolean;
    membershipTypeId: number;
    membershipSizeId: number;
    
}