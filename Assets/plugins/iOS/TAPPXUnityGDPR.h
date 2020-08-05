#import <UIKit/UIKit.h>
extern "C" {
#import <TappxFramework/TappxAds.h>
}

@interface TAPPXUnityGDPR : UIViewController {}

+ (void)acceptPersonalInfoContent:(BOOL)accept;
+ (void)setGDPRConsent:(NSString*)consent;

@end

