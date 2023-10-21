mergeInto(LibraryManager.library, {

  Hello: function() {
    window.alert("Hello, world!");
  },

  SaveExtern: function(data) {
      var dateString = UTF8ToString(data);
      var myobj = JSON.parse(dateString);
      player.setData(myobj);
    },


    LoadExtern: function(){
      player.getData().then(_data => {
          const myJSON = JSON.stringify(_data);
          myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
      });
  },

  RateGame: function() {
ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
    
  },

  ShowAdv: function() {
ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          // some action after close
        },
        onError: function(error) {
          // some action on error
        }
    }
})
    
  },

  AddCoinsExtern: function(value) {
ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
          myGameInstance.SendMessage("BalanceManager", "AddCoinsAndGoBack", value);
        },
        onClose: () => {
          console.log('Video ad closed.');
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
    

  },

  UnblockTrackExtern: function() {
ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
          myGameInstance.SendMessage("PurchasePopupManager", "UnlockTrackSuccess");
        },
        onClose: () => {
          console.log('Video ad closed.');
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
    

  },


});